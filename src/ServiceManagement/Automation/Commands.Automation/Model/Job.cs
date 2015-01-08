﻿// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Job object.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        /// <param name="accountName">
        /// The account name.
        /// </param>
        /// <param name="Job">
        /// The Job.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public Job(string accountName, Azure.Management.Automation.Models.Job job)
        {
            Requires.Argument("job", job).NotNull();
            Requires.Argument("accountName", accountName).NotNull();

            this.AutomationAccountName = accountName;
            this.Name = job.Name;
            this.Location = job.Location;
            this.Type = job.Type;
            this.Tags = job.Tags ?? new Dictionary<string, string>();
            this.Id = job.Id;

            if (job.Properties == null) return;

            this.CreationTime = job.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = job.Properties.LastModifiedTime.ToLocalTime();
            this.StartTime = job.Properties.StartTime;
            this.Status = job.Properties.Status;
            this.StatusDetails = job.Properties.StatusDetails;
            this.RunbookName = job.Properties.Runbook.Name;
            this.Exception = job.Properties.Exception;
            this.EndTime = job.Properties.EndTime;
            this.LastStatusModifiedTime = job.Properties.LastStatusModifiedTime;
            this.Parameters = job.Properties.Parameters ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        public Job()
        {
        }

        /// <summary>
        /// Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the status of the job.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the status details of the job.
        /// </summary>
        public string StatusDetails { get; set; }

        /// <summary>
        /// Gets or sets the start time of the job.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the job.
        /// </summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// Gets or sets the exception of the job.
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Gets or sets the last modified time of the job.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the last status modified time of the job."
        /// </summary>
        public DateTimeOffset LastStatusModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the parameters of the job.
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the runbook.
        /// </summary>
        public string RunbookName { get; set; }
    }
}
