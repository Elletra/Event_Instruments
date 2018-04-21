function fxDTSBrick::playPhrase(%this, %instrumentHash, %phrase) {
  %instrument = $Instruments::Server::HashToName[%instrumentHash];

  if (%instrument $= "") {
    return;
  }

  if (%this.isPlayingInstrument) {
    %this.stopPlaying();
  }

  %phrase = InstrumentsServer.fixEventPhrase(%phrase);

  %this.instrument = %instrument;
  InstrumentsServer.playPhrase(%this, %phrase);
}

function fxDTSBrick::stopPlaying(%this) {
  InstrumentsServer.stopPlaying(%this);
}
