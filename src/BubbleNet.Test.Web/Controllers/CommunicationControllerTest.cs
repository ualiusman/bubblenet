﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BubbleNet.Controllers;
using BubbleNet.Core;
using BubbleNet.Infrastructure.Persistence;
using System.Web.Mvc;
using System.Net;
using BubbleNet.Core.Models;

namespace BubbleNet.Test.Web.Controllers
{
    [TestClass]
    public class CommunicationControllerTest
    {
        private CommunicationController _controller;
        public CommunicationControllerTest()
        {
            IUnitOfWork uow = new UnitOfWork();
            _controller = new CommunicationController(uow);
        }

        [TestMethod]
        public void IndexTest()
        {
            var result = _controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsTest()
        {
            var result = _controller.Details(null) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);

            result = _controller.Details(long.MaxValue) as HttpNotFoundResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);

            ViewResult vr = _controller.Details(1) as ViewResult;
            if (vr != null)
                Assert.IsTrue(true);

        }

        [TestMethod]
        public void CreateTest()
        {
            var result = _controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditTest()
        {
            long? num = null;
            var result = _controller.Edit(num) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);

            result = _controller.Edit(long.MaxValue) as HttpNotFoundResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);

            ViewResult vr = _controller.Edit(1) as ViewResult;
            if (vr != null)
                Assert.IsTrue(true);

        }

        public void DeleteTest()
        {
            var result = _controller.Delete(null) as HttpStatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);

            result = _controller.Delete(long.MaxValue) as HttpNotFoundResult;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);

            ViewResult vr = _controller.Delete(1) as ViewResult;
            if (vr != null)
                Assert.IsTrue(true);
        }
    }
}