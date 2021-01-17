using System.Collections.Generic;

namespace Test.Data
{
    internal static class AssetPathWeaponManager
    {
        public static readonly Dictionary<WeaponType, string> Path
            = new Dictionary<WeaponType, string>
            {
                {WeaponType.Bullet, "Sphere"}
            };
    }
}
