using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstApp.Models
{
    public class SendEvent : PubSubEvent<string>
    {
    }
}
