using System.Linq;
using NUnit.Framework;
using Test.Systems;
using UnityEngine;

namespace Test.Test
{
    [TestFixture]
    internal sealed class TestInitTest
    {
        [NUnit.Framework.Test]
        public void Init()
        {
            Contexts contexts = new Contexts();
            TestInit testInit = new TestInit(contexts);
            
            testInit.Initialize();
            var gameEntity = contexts.game.GetEntities().Single(entity => entity.hasPosition 
                                                                          && entity.hasView && entity.isPlayer);
            Assert.NotNull(gameEntity);
            Assert.AreEqual(Vector3.one, gameEntity.position.Value);
        }
    }
}
