using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using L6;

namespace L6Tests
{
    [TestClass]
    public class L6Tests
    {
        [TestMethod]
        public void E1_TestEquality()
        {
            Lane BotSupp = new Lane("Bot", "God");
            Lane BotAdc = new Lane("Bot", "God");
            Assert.AreEqual(BotSupp, BotAdc);
        }

        [TestMethod]
        public void E1_TestHeroName()
        {
            Hero Teemo = new Hero("Teemo", "Top", "Lul");
            Assert.AreEqual("Teemo", Teemo.Name);
        }

        [TestMethod]
        public void E1_TestHeroLane()
        {
            Hero Teemo = new Hero("Teemo", "Top", "Lul");
            Assert.AreEqual("Top", Teemo.GetLaneName());
        }

        [TestMethod]
        public void E1_TestHeroTier()
        {
            Hero Teemo = new Hero("Teemo", "Top", "Lul");
            Assert.AreEqual("Lul", Teemo.GetTierName());
        }

        [TestMethod]
        public void E1_TestHeroTierWrong()
        {
            Hero Teemo = new Hero("Teemo", "Top", "Lul");
            Assert.AreNotEqual("God", Teemo.GetTierName());
        }

        [TestMethod]
        public void E1_TestHeroLaneWrong()
        {
            Hero Teemo = new Hero("Teemo", "Top", "Lul");
            Assert.AreNotEqual("Bot", Teemo.GetLaneName());
        }

        [TestMethod]
        public void E1_TestLaneTier()
        {
            L6.L6 l6 = new L6.L6();
            Lane Top = new Lane("Top", "God");
            Assert.AreEqual("God", Top.GetTierName());
        }

        [TestMethod]
        public void E1_TestLaneTierWrong()
        {
            L6.L6 l6 = new L6.L6();
            Lane Top = new Lane("Top", "God");
            Assert.AreNotEqual("Trash", Top.GetTierName());
        }

        [TestMethod]
        public void E2_TestAddLane()
        {
            L6.L6 l6 = new L6.L6();
            Lane Top = new Lane("Top", "God");
            l6.SetTier(new Tier("God"));
            Assert.AreEqual(true, l6.AddLane(Top));
        }

        [TestMethod]
        public void E2_TestAddLanes()
        {
            L6.L6 l6 = new L6.L6();
            Lane Top = new Lane("Top", "God");
            Lane Mid = new Lane("Mid", "God");
            l6.SetTier(new Tier("God"));
            l6.AddLane(Top);
            l6.AddLane(Mid);
            Assert.AreEqual(2, l6.Lanes.Count);
        }

        [TestMethod]
        public void E2_TestAddLaneTwice()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            l6.SetTier(new Tier("God"));
            l6.AddLane(Mid);
            Assert.AreEqual(false, l6.AddLane(Mid));
        }

        [TestMethod]
        public void E2_TestAddLaneNoTier()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            l6.AddLane(Mid);
            Assert.AreEqual(null, l6.AddLane(Mid));
        }

        [TestMethod]
        public void E2_TestAddLaneWrongTier()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            l6.SetTier(new Tier("Trash"));
            l6.AddLane(Mid);
            Assert.AreEqual(null, l6.AddLane(Mid));
        }

        [TestMethod]
        public void E2_TestAddLaneNoContraints()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Lane TopTrash = new Lane("Top", "Trash");
            l6.SetTier(new Tier("Trash"));
            l6.AddLane(Mid);
            Assert.AreEqual(true, l6.AddLaneIgnoreConstraints(TopTrash));
        }

        [TestMethod]
        public void E3_TestAddHero()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Hero Syndra = new Hero("Syndra", "Mid", "God");
            l6.SetTier(new Tier("God"));
            l6.AddLane(Mid);
            Assert.AreEqual(true, l6.AddHero(Syndra));
        }

        [TestMethod]
        public void E3_TestAddHeros()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Lane Top = new Lane("Top", "God");
            Hero Syndra = new Hero("Syndra", "Mid", "God");
            Hero Kennen = new Hero("Kennen", "Top", "God");
            l6.SetTier(new Tier("God"));
            l6.AddLane(Mid);
            l6.AddLane(Top);
            l6.AddHero(Syndra);
            l6.AddHero(Kennen);
            Assert.AreEqual(2, l6.Heroes.Count);
        }

        [TestMethod]
        public void E3_TestAddHeroTwice()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Hero Syndra = new Hero("Syndra", "Mid", "God");
            l6.SetTier(new Tier("God"));
            l6.AddLane(Mid);
            l6.AddHero(Syndra);
            Assert.AreEqual(false, l6.AddHero(Syndra));
        }

        [TestMethod]
        public void E3_TestAddHeroNoLane()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Hero Syndra = new Hero("Syndra", "Mid", "God");
            l6.SetTier(new Tier("God"));
            Assert.AreEqual(null, l6.AddHero(Syndra));
        }

        [TestMethod]
        public void E3_TestAddHeroNoTier()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Hero Syndra = new Hero("Syndra", "Mid", "God");
            Assert.AreEqual(null, l6.AddHero(Syndra));
        }

        [TestMethod]
        public void E3_TestAddHeroNullHero()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            l6.SetTier(new Tier("God"));
            Assert.AreEqual(null, l6.AddHero(null));
        }

        [TestMethod]
        public void E3_TestAreAllLanesDifferent()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Lane Top = new Lane("Top", "God");
            Hero Syndra = new Hero("Syndra", "Mid", "God");
            Hero Kennen = new Hero("Kennen", "Top", "God");
            l6.SetTier(new Tier("God"));
            l6.AddLane(Mid);
            l6.AddLane(Top);
            l6.AddHero(Syndra);
            l6.AddHero(Kennen);
            Assert.AreEqual(true, l6.AreAllLanesDifferent());
        }

        [TestMethod]
        public void E3_TestAreAllLanesDifferentFalse()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Hero Syndra = new Hero("Syndra", "Mid", "God");
            Hero Vladimir = new Hero("Vladimir", "Mid", "God");
            l6.SetTier(new Tier("God"));
            l6.AddLane(Mid);
            l6.AddHero(Syndra);
            l6.AddHero(Vladimir);
            Assert.AreEqual(false, l6.AreAllLanesDifferent());
        }

        [TestMethod]
        public void E3_TestAreAllLanesDifferentEmptyHeros()
        {
            L6.L6 l6 = new L6.L6();
            Lane Mid = new Lane("Mid", "God");
            Lane Top = new Lane("Top", "God");
            Hero Syndra = new Hero("Syndra", "Mid", "God");
            Hero Kennen = new Hero("Kennen", "Top", "God");
            l6.SetTier(new Tier("God"));
            l6.AddLane(Mid);
            l6.AddLane(Top);
            Assert.AreEqual(null, l6.AreAllLanesDifferent());
        }
    }
}
