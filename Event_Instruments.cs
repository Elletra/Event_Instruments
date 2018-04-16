function InstrumentsServer::fixEventPhrase(%this, %phrase) {
  return strReplace(%phrase, "!", ";");
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


%list = "list";
%count = InstrumentsServer.instrumentCount;

for (%i = %count - 1; %i >= 0; %i--) {
  %instrument = InstrumentsServer.name(%i);

  if (_strEmpty(%instrument)) {
    continue;
  }

  %list = %list SPC %instrument SPC %i;
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
