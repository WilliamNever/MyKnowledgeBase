using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StandardBaseInfors.TestModels
{
    public delegate void DoSomething(string sth);
    public class ModelClass
    {
        private static readonly object EVENT_DOING = new object();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Memo { get; set; }
        public string IDCard { get { return iDCard; } }
        public string NameWithAge { get { return $"{FirstName} {LastName} / {Age}"; } }
        private string Name { get { return $"{FirstName} {LastName}"; } }

        //private event DoSomething Doing;
        /// <summary>
        /// for private field test
        /// </summary>
        private string iDCard;

        private static int ModelClassNumber;

        public ModelClass()
        {
            ModelClassNumber++;
            Doing += DoingFrist;
        }

        public void GoAction(string str)
        {
            OnDoing(str);
        }

        protected virtual void OnDoing(string str)
        {
            DoSomething handler = (DoSomething)Events[EVENT_DOING];
            if (handler != null) handler(str);
        }

        private void DoingFrist(string str)
        {
            Memo += $" - {str}";
        }

        public int GetModelClassNumber()
        {
            return ModelClassNumber;
        }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        private string GetNameWithAge()
        {
            return $"{FirstName} {LastName} / {Age}";
        }
        public void SetIDCard(string IdCard)
        {
            iDCard = IdCard;
        }

        protected EventHandlerList Events
        {
            get
            {
                if (events == null)
                {
                    events = new EventHandlerList();
                }

                return events;
            }
        }
        private EventHandlerList events;

        public event DoSomething Doing
        {
            add
            {
                Events.AddHandler(EVENT_DOING, value);
            }
            remove
            {
                Events.RemoveHandler(EVENT_DOING, value);
            }
        }
    }
}
