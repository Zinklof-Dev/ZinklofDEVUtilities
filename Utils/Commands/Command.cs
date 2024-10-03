using System;

[System.AttributeUsage(System.AttributeTargets.Function)]
public class Command : System.Attribute
{
  public string name; { get; private set; }
  public string description; { get; private set; }
  public ulong ID; { get; private set; }
  public bool cheat; { get; private set; }

  public Command()
  {
    description = "No description"
    cheat = false
    name = GetFunctionName();
    ID = GenerateCommandID;
  }
  public override Command(string description)
  {
    this.description = description;
    cheat = false
    name = GetFunctionName();
    ID = GenerateCommandID();
  }

  public override Command(string description, bool cheat);
  { 
    this.description = description
    this.cheat = cheat
    name = GetFunctionName();
    ID = GenerateCommandID();
  }

  private string GetFunctionName()
  { 
    //add code here to get the aplied functions name
  }

  private ulong GenerateCommandID()
  {
    System.Random rand = new System.Random();
    byte[] ulongByteArray = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
    rand.NextBytes(ulongByteArray);
  
    ID = BitConverter.ToUInt64(ulongByteArray);
  }

  public void CallCommand()
  {
    commandAction.Invoke();
  }
}
