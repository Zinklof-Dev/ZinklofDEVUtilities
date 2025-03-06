using System;

/*
techreport | oneill:pcg2014

title : PCG: A Family of Simple Fast Space-Efficient Statistically Good Algorithms for Random Number Generation
author : Melissa E. O'Neill
institution : Harvey Mudd College
address : Claremont, CA
number : HMC-CS-2014-0905
year : 2014
month : Sep
xurl : https://www.cs.hmc.edu/tr/hmc-cs-2014-0905.pdf
*/

/// <summary>
/// Zrand is a random number generation class that uses the PCG RNG family of algorithms, which are code line efficient, memory efficient, speed efficient, and pretty random compared to other PRNGs. (Dont ask my source, I trusted their site :D) | 
/// Specifically this is the PCG-XSL-RR 128/64 algorithm. which has a state of 128 bits, and can output 64 bit numbers, and is one of the fastest members in the family, albeit not as good statistically speaking with its outputs. |
/// Uses 16 bytes of memory when existing
/// </summary>
public class Zrand64
{
    private ulong state;
    private ulong inc;

    static ulong multiplier = 6364136223846793005u;

    public Zrand64(ulong seed)
    {
        state = seed;
        inc = 1442695040888963407u;
    }

    public Zrand64 (ulong seed, ulong increment)
    {
        state = seed;
        inc = increment;
    }

    public void ReSeed(ulong seed)
    {
        state = seed;
    }

    public void ReSeed(ulong seed, ulong increment)
    {
        state = seed;
        inc = increment;
    }

    public ulong Next()
    {
        ulong oldState = state;

        state = oldState * multiplier + inc;

        int count = (int)(oldState >> 122);
        ulong x64 = oldState ^ (oldState >> 64);

        return (x64 >> count) | (x64 << (64 - count));
    }

    public ulong NextRange(ulong min, ulong max)
    {
        ulong range_width = max - min + 1;
        return min + (Next() % range_width);
    }

    public double NextDouble() // 0-1
    {
        return (Double)(Next() / ulong.MaxValue);
    }

    public double DoubleRange(Double min, Double max)
    {
        return (Double)((min + (min - max)) * (Next() / ulong.MaxValue));
    }
}


/// <summary>
/// Zrand is a random number generation class that uses the PCG RNG family of algorithms, which are code line efficient, memory efficient, speed efficient, and pretty random compared to other PRNGs. (Dont ask my source, I trusted their site :D) | 
/// Specifically this is the PCG-XSH-RR 64/32 algorithm. which has a state of 64 bits, and can output 32 bit numbers, and is one of the faster members in the family, and is statistically superior to the algorithm used in Zrand64.
/// Uses 16 bytes of memory when existing
/// </summary>
public class Zrand32
{
    ulong state;
    ulong inc;

    ulong multiple = 6364136223846793005u;

    public uint Next()
    {
        ulong oldState = state;

        state = state * multiple + inc;

        int count = (int)(oldState >> 59);
        oldState ^= oldState >> 18;
        uint x = (uint)(oldState >> 27);

        return (x >> count) | (x << (32 - count));
    }
}
