namespace TronSharp
{
    public static class TronUnit
    {
        private static long _sun_unit = 1_000_000L;

        public static long TRXToSun(decimal trx)
        {
            return Convert.ToInt64(trx * _sun_unit);
        }

        public static decimal SunToTRX(long sun)
        {
            return Convert.ToDecimal(sun) / _sun_unit;
        }

    }
}
