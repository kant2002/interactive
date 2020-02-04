// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using Microsoft.DotNet.Interactive.Commands;
using Newtonsoft.Json;

namespace Microsoft.DotNet.Interactive.Events
{
    public class InputRequested : KernelEventBase
    {
        [JsonConstructor]
        internal InputRequested(string prompt, bool isPassword)
        {
            Prompt = prompt;
            Password = isPassword;
        }

        public InputRequested(
            string prompt,
            bool isPassword,
            IKernelCommand command) : base(command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            Prompt = prompt;
            Password = isPassword;
        }

        [JsonIgnore]
        public string Input { get; set; }
        public string Prompt { get; }
        public bool Password { get; }

        public override string ToString() => $"{nameof(InputRequested)}: Prompt-'{Prompt}' Password-'{Password}'";
    }
}
