using System;

public class Zrand // this doesn't break naming convention, it is meant to be one whole word :D
{
  public ulong seed;
  private ulong state;

  public Zrand()
  {
    DateTime dt = DateTime.Now()
    
    this.seed = ((dt.Second * (dt.Minute - dt.Hour)) * (((dt.Year - dt.Day) * dt.Month) - dt.DayOfYear)) * dt.Milisecond // just some random stuff so randomly created classes have a "random" seed. used system time because most PRNGs use it, easy way to rarely have the same seed.
    state = seed;
  }

  public Zrand(ulong seed)
  {
    this.seed = seed;
    state = seed;
  }
  
  public void Reset()
  {
    state = seed;
  }

  /// <Summary>
  /// Returns a psuedo random Ulong. Quick and cheap, good for realtime use, but can be unreliable.
  /// <Summary>
  public ulong XorShift()
  {
    state ^= (state << 13);
    state ^= (state >> 17);
    state ^= (state << 5);
    state &= 0xFFFFFFFFFFFFFFFF;

    return state;
  }
  
}
