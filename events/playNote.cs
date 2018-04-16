function fxDTSBrick::playNote(%this, %instrumentIndex, %note) {
  if (!InstrumentsServer.validateInstrumentIndex(%instrumentIndex)) {
    return;
  }

  %instrument = InstrumentsServer.name(%instrumentIndex);

  if (%this.isPlayingInstrument) {
    %this.stopPlaying();
  }

  %this.instrument = %instrument;
  InstrumentsServer.playNote(%this, %note, %instrument);
}

function fxDTSBrick::playRandomNote(%this, %instrumentIndex) {
  if (!InstrumentsServer.validateInstrumentIndex(%instrumentIndex)) {
    return;
  }

  %instrument = InstrumentsServer.name(%instrumentIndex);

  if (%this.isPlayingInstrument) {
    %this.stopPlaying();
  }

  %this.instrument = %instrument;
  InstrumentsServer.playRandomNote(%this, %instrument);
}
