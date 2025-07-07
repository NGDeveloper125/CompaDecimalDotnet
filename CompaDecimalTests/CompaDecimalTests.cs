using CompaDecimalSystem;
using System.Numerics;

namespace CompaDecimalTests;

public class CompaDecimalTests
{
    [Fact]
    public void ToCompaDecimal_Tests()
    {
        int value1 = 123456789;
        CompaDecimal compaDecimal = value1.ToCompaDecimal();
        Assert.NotNull(compaDecimal);
        Assert.Equal("1T~PC", compaDecimal.Value); 

        long value2 = 1234567345346389;
        compaDecimal = value2.ToCompaDecimal();
        Assert.NotNull(compaDecimal);
        Assert.Equal("d#R Ielj", compaDecimal.Value);

        long value3 = 3631234567864339;
        compaDecimal = value3.ToCompaDecimal();
        Assert.NotNull(compaDecimal);
        Assert.Equal("u~<WPwE4", compaDecimal.Value); 

        long value4 = 013243341566778899;
        compaDecimal = value4.ToCompaDecimal();
        Assert.NotNull(compaDecimal);
        Assert.Equal("1~Z\\QIdB[", compaDecimal.Value);

        BigInteger value5 = BigInteger.Parse("13243343453464363477543259823579234728358069289387523905896263897520398239578398562796720387095283578358927502938520395823095708674021566778899");
        compaDecimal = value5.ToCompaDecimal();
        Assert.NotNull(compaDecimal);
        Assert.Equal("UuCgSeAb(?Yz8@$DWA7@m?@_^F1NFz:a~\\I_j~fwfup(fG>?j)prWrj2wd,-hMm#visdWh+y", compaDecimal.Value);
    }

    [Fact]
    public void ToInt_Tests()
    {
        CompaDecimal compaDecimal1 = new CompaDecimal("1T~PC");
        int intValue1 = compaDecimal1.ToInt();
        Assert.Equal(123456789, intValue1);

        CompaDecimal compaDecimal2 = new CompaDecimal("d#R Ielj");
        long longValue2 = compaDecimal2.ToLong();
        Assert.Equal(1234567345346389, longValue2);

        CompaDecimal compaDecimal3 = new CompaDecimal("u~<WPwE4");
        long longValue3 = compaDecimal3.ToLong();
        Assert.Equal(3631234567864339, longValue3);

        CompaDecimal compaDecimal4 = new CompaDecimal("1~Z\\QIdB[");
        long longValue4 = compaDecimal4.ToLong();
        Assert.Equal(013243341566778899, longValue4);

        CompaDecimal compaDecimal5 = new CompaDecimal("UuCgSeAb(?Yz8@$DWA7@m?@_^F1NFz:a~\\I_j~fwfup(fG>?j)prWrj2wd,-hMm#visdWh+y");
        BigInteger bigIntegerValue5 = compaDecimal5.ToBigInteger();
        Assert.Equal(BigInteger.Parse("13243343453464363477543259823579234728358069289387523905896263897520398239578398562796720387095283578358927502938520395823095708674021566778899"), bigIntegerValue5);
    }
}
