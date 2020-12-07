using NLog;
using NLog.LayoutRenderers;
using System;
using System.Text;

/*
 * 
 * To use the extend for NLog, to add a new log level
 * Steps:
 * . add this file to the project
 * . add NLog config in Configure method in Startup.cs
 *   NLog.Config.ConfigurationItemFactory.Default.LayoutRenderers.RegisterDefinition("levelx", typeof(Extends.LevelExLayoutRenderer));
 * . update ${level} to ${levelx} nlog.config
 * . To use the new log level
 *   var _OrderLogger = NLog.LogManager.GetLogger(typeof(OrdersController).ToString());
 *   _OrderLogger.LogOrder($"Order inbound for customer {customer_id}: {JsonConvert.SerializeObject(order)}");
 * 
 */

namespace TaylorCorp.BOS.Api.Extends
{
    public static class NLogExtend
    {
        /// <summary>
        /// add a new log level, Order
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void LogOrder(this ILogger logger, string message = "Order inbound for customer")
        {
            var logEventInfo = new LogEventInfo(LogLevel.Error, logger.Name, message);
            logEventInfo.Properties["custLevel"] = Tuple.Create(9, "Order");
            logger.Log(logEventInfo);
        }
    }

    [LayoutRenderer("levelx")]
    public class LevelExLayoutRenderer : LevelLayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            if (logEvent.Level == LogLevel.Error && logEvent.Properties.ContainsKey("custLevel"))
            {
                Tuple<int, string> custLevel = logEvent.Properties["custLevel"] as Tuple<int, string>;
                if (custLevel == null)
                {
                    throw new InvalidCastException("Invalid Cast Tuple<int, string>");
                }

                switch (Format)
                {
                    case LevelFormat.Name:
                        builder.Append(custLevel.Item2);
                        break;
                    case LevelFormat.FirstCharacter:
                        builder.Append(custLevel.Item2[0]);
                        break;
                    case LevelFormat.Ordinal:
                        builder.Append(custLevel.Item1);
                        break;
                    default:
                        builder.Append("Missed Log level");
                        break;
                }
            }
            else
            {
                base.Append(builder, logEvent);
            }
        }
    }
}
