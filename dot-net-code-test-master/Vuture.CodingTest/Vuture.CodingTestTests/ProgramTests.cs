using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vuture.CodingTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuture.CodingTest.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        Program p = new Program();

        [TestMethod()]
        public void countLettersTest()
        {
            Assert.AreEqual(5, p.countLetters("I have some cheese", 'e'));
        }

        [TestMethod()]
        public void palindromeCheckTest()
        {
            Assert.IsFalse(p.palindromeCheck("aaron"));
            Assert.IsTrue(p.palindromeCheck("anna"));
            Assert.IsFalse(p.palindromeCheck("anna1"));
            Assert.IsTrue(p.palindromeCheck("anNa"));
            Assert.IsTrue(p.palindromeCheck("a n n a"));
            Assert.IsFalse(p.palindromeCheck("I have some cheese"));
            Assert.IsTrue(p.palindromeCheck("God saved Eva's dog"));
        }

        [TestMethod()]
        public void countNumCensoredWordsTest()
        {
            Assert.AreEqual(p.countNumCensoredWords(new string[] { "yellow", "orange", "blue" }, "Some of the best colours are red yellow green and orange and grey and orange orange oranges"), 5);
            Assert.AreEqual(p.countNumCensoredWords(new string[] { "dog", "cat", "large" }, "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse."), 4);
        }

        [TestMethod()]
        public void censorChosenWordsTest()
        {
            Assert.AreEqual(p.censorChosenWords(new string[] { "meow", "woof" }, "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse."), "I have a cat named M$$w and a dog name W$$f. I love the dog a lot. He is larger than a small horse.");
        }

        [TestMethod()]
        public void censorPalindromesTest()
        {
            Assert.AreEqual(p.censorPalindromes("Anna went to vote in the election to fulfil her civic duty"), "A$$a went to vote in the election to fulfil her c$$$c duty");
        }
    }

}