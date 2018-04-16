function fxDTSBrick::playSong(%this, %instrumentIndex, %song) {
  if (!InstrumentsServer.validateInstrumentIndex(%instrumentIndex)) {
    return;
  }

  %instrument = InstrumentsServer.name(%instrumentIndex);

  if (%this.isPlayingInstrument) {
    %this.stopPlaying();
  }

  %this.instrument = %instrument;
  InstrumentsServer.playSong(%this, %song);
}

function fxDTSBrick::setSongPhrase(%this, %index, %phrase) {
  if (!_isInt(%index) || strPos(%index, ".") != -1 || striPos(%index, "e") != -1) {
    return;
  }

  if (strLen(%phrase) > Instruments.const["MAX_PHRASE_LENGTH"]) {
    return;
  }

  %phrase = InstrumentsServer.fixEventPhrase(%phrase);
  %this.songPhrase[%index] = %phrase;
}
