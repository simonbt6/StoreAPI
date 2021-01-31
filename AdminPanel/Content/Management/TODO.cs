using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.Content.Management
{
    public class TODO
    {
        private readonly string Title;
        private readonly string Description;
        /**
         * 0 - Normal
         * 1 - Soon
         * 2 - Urgent
         **/
        private readonly int Priority;
        private readonly int UserId;
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public DateTime StartingAt { get; }
        public DateTime EndingAt { get; }

        public TODO(string Title, string Description, int UserId, int Priority, DateTime CreatedAt, DateTime UpdatedAt, DateTime StartingAt, DateTime EndingAt)
        {
            this.Title = Title;
            this.Description = Description;
            this.UserId = UserId;
            this.Priority = Priority;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.StartingAt = StartingAt;
            this.EndingAt = EndingAt;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetDescription()
        {
            return Description;
        }

        /**
         * <summary>
         * Gets the priority of the TODO.
         * </summary>
         **/
        public int GetPriority()
        {
            return Priority;
        }

        public int GetUserId()
        {
            return UserId;
        }

    }
}
