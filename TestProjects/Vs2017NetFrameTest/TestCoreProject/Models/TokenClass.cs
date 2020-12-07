using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestCoreProject.Models
{
    [Serializable]
    public class TokenClass
    {
        public CancellationTokenSource cts { get; set; }
        public string TokenName { get; set; } = "Default Token";

        public TokenClass()
        {
            cts = new CancellationTokenSource();
        }
        public TokenClass(string TokenName):this()
        {
            this.TokenName = TokenName;
        }
        public void SetTokenName(string tokenName)
        {
            TokenName = tokenName;
        }
    }
}
