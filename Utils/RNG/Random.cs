using System;

/// <summary>
/// Zrand is a random number generation class that uses the PCG RNG algorithm, which is code line efficient, memory efficient, speed efficient, and pretty random compared to other PRNGs. (Dont ask my source, I trusted their site :D) | 
/// This particular implimentation uses a 64 bit state, 64 bit increment, and 64 bit multiplier, resulting in 24 bytes of memory usage, compared to the base C# random class using 232 (that number on the base random comes from a random github user, don't quote me) |
/// Specifically this is the PCG-XSH-RR
/// </summary>
public class Zrand // this doesn't break naming convention, it is meant to be one whole word :D
{
    // to impliment at home. will also make a version using PCG-XSH-RS which is slightly faster and uses 8 less bytes of memory, at the cost of having less possible outputs.
}
