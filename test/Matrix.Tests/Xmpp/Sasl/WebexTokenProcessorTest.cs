﻿/*
 * Copyright (c) 2003-2017 by AG-Software <info@ag-software.de>
 *
 * All Rights Reserved.
 * See the COPYING file for more information.
 *
 * This file is part of the MatriX project.
 *
 * NOTICE: All information contained herein is, and remains the property
 * of AG-Software and its suppliers, if any.
 * The intellectual and technical concepts contained herein are proprietary
 * to AG-Software and its suppliers and may be covered by German and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 *
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from AG-Software.
 *
 * Contact information for AG-Software is available at http://www.ag-software.de
 */

namespace Matrix.Tests.Xmpp.Sasl
{
    using Matrix.Xml;
    using Shouldly;
    using Xunit;
    using Moq;
    using Matrix.Xmpp.Sasl;
    using System.Threading.Tasks;
    using Matrix.Xmpp.Sasl.Processor.WebexToken;
    using System.Threading;

    public class WebexTokenProcessorTest
    {
        [Fact]
        public async Task Test_Authentication_Message()
        {
            var expectedXml = "<auth mechanism='WEBEX-TOKEN' xmlns='urn:ietf:params:xml:ns:xmpp-sasl'>Zm9v</auth>";

            var webexTokeSasl = new WebexTokenProcessor("foo");

            Mock<XmppClient> mockXmppClient = new Mock<XmppClient>();
            mockXmppClient
                .Setup(s => s.SendAsync<Success, Failure>(It.IsAny<XmppXElement>(), It.IsAny<CancellationToken>()))
               .Callback<XmppXElement, CancellationToken>((el, ct) =>
                {
                    el.ShouldBe(expectedXml);
                })
               .Returns(Task.FromResult<XmppXElement>(new Success()));

            var res = await webexTokeSasl.AuthenticateClientAsync(mockXmppClient.Object, CancellationToken.None);
        }
    }
}
