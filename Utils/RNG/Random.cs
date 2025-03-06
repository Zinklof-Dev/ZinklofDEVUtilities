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
/// Uses 16 bytes of memory when existing, and an additional 
/// </summary>
public class Zrand64
{
    private ulong State;
    private ulong inc;

    ulong Next()
    {
        ulong oldState = state;

        state = oldState * 6364136223846793005U + inc;

        ulong XorShift = ((oldState >> 18) ^ oldState) >> 27;
        ulong rot = oldState >> 59;

        return (XorShift >> rot) ^ (XorShift << (64 - rot));
    }

    ulong NextRange(ulong min, ulong max)
    {
        ulong range_width = max - min + 1;
        return min + (Next() % range_width);
    }

    double NextDouble() // 0-1
    {
        return (Double)(Next() / ulong.MaxValue());
    }

    Double DoubleRange(Double min, Double max);
    {
        return (Double)((min + (min - max)) * (Next() / ulong.MaxValue()));
    }
}
