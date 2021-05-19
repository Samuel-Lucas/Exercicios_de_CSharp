using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using ExercicioComposicao.Entities.Enum;

namespace ExercicioComposicao.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public List<OrderItem> ItemList { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            this.Status = status;
            Client = client;
        }

        public void addItem(OrderItem item)
        {
            ItemList.Add(item);
        }

        public void removeItem(OrderItem item)
        {
            ItemList.Remove(item);
        }

        public double total()
        {
            double sum = 0.0;
            foreach (OrderItem item in ItemList)
            {
                sum += item.subTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItem item in ItemList)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
