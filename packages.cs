package Event_Instruments {
  function fxDTSBrick::onDeath(%obj) {
    Parent::onDeath(%obj);

    if (%obj.isPlayingInstrument) {
      %obj.stopPlaying();
    }
  }

  function serverCmdAddEvent(%client, %enabled, %inputEventIdx, %delay, %targetIdx, %NTNameIdx, %outputEventIdx, %par1, %par2, %par3, %par4) {
    %outputEventName = $OutputEvent_NamefxDTSBrick_[%outputEventIdx];

    switch$ (%outputEventName) {
      case "playNote" or "playRandomNote" or "playPhrase" or "playSong":
        %fallbackHash = InstrumentsServer.getInstrumentHash(InstrumentsServer.name(0));

        // Accounting for old version of Event_Instruments
        if (strLen(%par1) <= 2) {
          %instrument = InstrumentsServer.name(%par1);

          if (%instrument $= "") {
            warn("WARNING: loadBricks() - Unknown instrument index \"" @ %par1 @ "\" for " @ %outputEventName @ " event!");
            %par1 = %fallbackHash;
          }
          else {
            %par1 = InstrumentsServer.getInstrumentHash(%instrument);
          }
        }
        // Otherwise let's check if the hash exists on this server
        else if ($Instruments::Server::HashToName[%par1] $= "") {
          warn("WARNING: loadBricks() - Instrument hash \"" @ %par1 @"\" not found!");
          %par1 = %fallbackHash;
        }
    }
    Parent::serverCmdAddEvent(%client, %enabled, %inputEventIdx, %delay, %targetIdx, %NTNameIdx, %outputEventIdx, %par1, %par2, %par3, %par4);
  }
};
activatePackage(Event_Instruments);
