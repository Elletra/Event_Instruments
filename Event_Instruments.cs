function InstrumentsServer::fixEventPhrase(%this, %phrase) {
  return strReplace(%phrase, "!", ";");
}

function InstrumentsServer::getInstrumentHash(%this, %name) {
  %hash = $Instruments::Server::NameToHash[%name];

  if (%hash $= "") {
    %crc = getStringCRC(%name);
    %truncateLength = %crc >= 0 ? 6 : 7;  // Need to account for the minus symbol in negative numbers
    %hash = getSubStr(%crc, 0, %truncateLength);

    $Instruments::Server::NameToHash[%name] = %hash;
    $Instruments::Server::HashToName[%hash] = %name;
  }

  return %hash;
}

function InstrumentsServer::validateInstrumentIndex(%this, %instrumentIndex) {
  if (_strEmpty(%instrumentIndex)) {
    return false;
  }

  %instrument = %this.getInstrumentFromIndex(%instrumentIndex);

  if (!isObject(%instrument)) {
    return false;
  }

  return true;
}

exec("./events/playNote.cs");
exec("./events/playPhrase.cs");
exec("./events/playSong.cs");

exec("./packages.cs");


function InstrumentsServer::initEvents(%this) {
  %list = "list";
  %count = InstrumentsServer.instrumentCount;

  for (%i = %count - 1; %i >= 0; %i--) {
    %instrument = InstrumentsServer.name(%i);

    if (_strEmpty(%instrument)) {
      continue;
    }

    %list = %list SPC %instrument SPC InstrumentsServer.getInstrumentHash(%instrument);
  }

  registerOutputEvent("fxDTSBrick", "playNote", %list TAB "string 64 120", 0);
  registerOutputEvent("fxDTSBrick", "playRandomNote", %list, 0);
  registerOutputEvent("fxDTSBrick", "playPhrase", %list TAB "string 200 255", 0);
  registerOutputEvent("fxDTSBrick", "playSong", %list TAB "string 200 255", 0);
  registerOutputEvent("fxDTSBrick", "setSongPhrase", "int 0 19 0\tstring 200 255", 0);
  registerOutputEvent("fxDTSBrick", "stopPlaying");

  registerInputEvent("fxDTSBrick", "onPhraseEnd", "Self fxDTSBrick" TAB "Player Player" TAB "Client GameConnection" TAB "MiniGame MiniGame");
  registerInputEvent("fxDTSBrick", "onPhraseLoop", "Self fxDTSBrick" TAB "Player Player" TAB "Client GameConnection" TAB "MiniGame MiniGame");
  registerInputEvent("fxDTSBrick", "onSongEnd", "Self fxDTSBrick" TAB "Player Player" TAB "Client GameConnection" TAB "MiniGame MiniGame");
  registerInputEvent("fxDTSBrick", "onSongLoop", "Self fxDTSBrick" TAB "Player Player" TAB "Client GameConnection" TAB "MiniGame MiniGame");
}

InstrumentsServer.initEvents();
