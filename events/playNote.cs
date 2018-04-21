function fxDTSBrick::playNote(%this, %instrumentHash, %note) {
  %instrument = $Instruments::Server::HashToName[%instrumentHash];

  if (%instrument $= "") {
    return;
  }

  if (%this.isPlayingInstrument) {
    %this.stopPlaying();
  }

  %this.instrument = %instrument;
  InstrumentsServer.playNote(%this, %note, %instrument);
}

function fxDTSBrick::playRandomNote(%this, %instrumentHash) {
  %instrument = $Instruments::Server::HashToName[%instrumentHash];

  if (%instrument $= "") {
    return;
  }

  if (%this.isPlayingInstrument) {
    %this.stopPlaying();
  }

  %this.instrument = %instrument;
  InstrumentsServer.playRandomNote(%this, %instrument);
}
