using Matrix.Core.Attributes;
using Matrix.Xmpp.Base;

namespace Matrix.Xmpp.Component
{
    [XmppTag(Name = "error", Namespace = Namespaces.Accept)]
    public class Error : Base.Error
    {
        public Error() : base(Namespaces.Accept)
        {
        }

        public Error(ErrorCondition condition)
            : this()
        {
            Condition = condition;
        }

        public Error(ErrorCondition condition, ErrorType type)
            : this(condition)
        {
            Type = type;
        }
    }
}