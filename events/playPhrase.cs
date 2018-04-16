function fxDTSBrick::playPhrase(%this, %instrumentIndex, %phrase) {
  if (!InstrumentsServer.validateInstrumentIndex(%instrumentIndex)) {
    return;
  }

  %instrument = InstrumentsServer.name(%instrumentIndex);

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
