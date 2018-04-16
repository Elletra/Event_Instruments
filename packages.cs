package Event_Instruments {
  function fxDTSBrick::onDeath(%obj) {
    Parent::onDeath(%obj);

    if (%obj.isPlayingInstrument) {
      %obj.stopPlaying();
    }
  }
};
activatePackage(Event_Instruments);
