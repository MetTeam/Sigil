﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sigil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigilTests
{
    [TestClass]
    public class LoadLocal
    {
        [TestMethod]
        public void Simple()
        {
            var e1 = Emit<Func<int>>.NewDynamicMethod("E1");

            var foo = e1.CreateLocal<int>("foo");

            e1.LoadLocal(foo);
            e1.LoadConstant(3);
            e1.Add();
            e1.Return();

            var del = e1.CreateDelegate();

            Assert.AreEqual(3, del());
        }
    }
}
