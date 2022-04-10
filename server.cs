if (isFunction("isAddOnEnabled") && isAddOnEnabled("System_Instruments")) {
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
