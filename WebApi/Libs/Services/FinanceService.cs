using Libs.Helps;
using Libs.interfaces;
using Libs.Reference;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{

    public class FinanceService
    {
        private ApplicationDbContext dbContext;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderDetailRepository;
        public FinanceService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.orderRepository = new OrderRepository(this.dbContext);
            this.orderDetailRepository = new OrderDetailRepository(this.dbContext);
        }
        public async Task<List<Statistical>> GetStatistical(QueryStatistical query)
        {
            List<Statistical> statisticals = new List<Statistical>(); 
            {
                var orders = dbContext.orders.AsQueryable();

                if (orders == null)
                {
                    return null;
                }
                else
                {

                    if (query.start != 0)
                    {
                        orders = orders.Where(s => s.Date.Month >= query.start);
                    }

                    if (query.end != 12)
                    {
                        orders = orders.Where(s => s.Date.Month <= query.end);
                    }
                    float[] totalPriceFollowMonth = new float[13];
                    foreach (var order in orders) { 
                        if(order.Date.Month == 1)
                            totalPriceFollowMonth[1] += order.totalPrice;
                        else if(order.Date.Month == 2)
                            totalPriceFollowMonth[2] += order.totalPrice;
                        else if (order.Date.Month == 3)
                            totalPriceFollowMonth[3] += order.totalPrice;
                        else if (order.Date.Month == 4)
                            totalPriceFollowMonth[4] += order.totalPrice;
                        else if (order.Date.Month == 5)
                            totalPriceFollowMonth[5] += order.totalPrice;
                        else if (order.Date.Month == 6)
                            totalPriceFollowMonth[6] += order.totalPrice;
                        else if (order.Date.Month == 7)
                            totalPriceFollowMonth[7] += order.totalPrice;
                        else if (order.Date.Month == 8)
                            totalPriceFollowMonth[8] += order.totalPrice;
                        else if (order.Date.Month == 9)
                            totalPriceFollowMonth[9] += order.totalPrice;
                        else if (order.Date.Month == 10)
                            totalPriceFollowMonth[10] += order.totalPrice;
                        else if (order.Date.Month == 11)
                            totalPriceFollowMonth[11] += order.totalPrice;
                        else if (order.Date.Month == 12)
                            totalPriceFollowMonth[12] += order.totalPrice;                     
                    }
                    
                    for (int i = query.start;i<=query.end;i++) {

                        statisticals.Add(new Statistical
                        {
                            Month =i,
                            total = totalPriceFollowMonth[i],
                        });

                    }

                    if (query.IsDecsendingByPrice == true)
                    {
                        statisticals.Sort((x1,x2) => x2.total.CompareTo(x1.total));
                    }
                    if (query.IsDecsendingByPrice == false)
                    {
                        statisticals.OrderByDescending(p => p.total).ToList();
                    }

                    return statisticals;



                }
            }
        }
    }
}
