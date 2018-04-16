if ($AddOn__System_Instruments == 1) {
  if (InstrumentsServer.instrumentCount > 0) {
    exec("./Event_Instruments.cs");
  }
  else {
    error("ERROR: No instruments enabled!");
  }
}
else {
  error("ERROR: System_Instruments must be enabled!");
}
