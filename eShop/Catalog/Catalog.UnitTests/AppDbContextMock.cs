namespace Catalog.UnitTests
{
    public class AppDbContextMock
    {
        public static TContext GetMock<TData, TContext>(List<TData> lstData,
            Expression<Func<TContext, DbSet<TData>>> dbSetSelectionExpression)
            where TData : class where TContext : DbContext
        {
            IQueryable<TData> lstDataQueryable = lstData.AsQueryable();
            Mock<DbSet<TData>> dbSetMock = new Mock<DbSet<TData>>();
            Mock<TContext> dbContext = new Mock<TContext>();

            dbSetMock.As<IQueryable<TData>>().Setup(s => s.Provider).Returns(lstDataQueryable.Provider);
            dbSetMock.As<IQueryable<TData>>().Setup(s => s.Expression).Returns(lstDataQueryable.Expression);
            dbSetMock.As<IQueryable<TData>>().Setup(s => s.ElementType).Returns(lstDataQueryable.ElementType);
            dbSetMock.As<IQueryable<TData>>().Setup(s => s.GetEnumerator()).Returns(() => lstDataQueryable.GetEnumerator());
            dbSetMock.Setup(x => x.AddAsync(It.IsAny<TData>(), CancellationToken.None)).ReturnsAsync((TData t, CancellationToken token) =>
            {
                lstData.Add(t);
                return default;
            });
            dbSetMock.Setup(x => x.AddRange(It.IsAny<IEnumerable<TData>>())).Callback<IEnumerable<TData>>(lstData.AddRange);
            dbSetMock.Setup(x => x.Remove(It.IsAny<TData>())).Callback<TData>(t => lstData.Remove(t));
            dbSetMock.Setup(x => x.RemoveRange(It.IsAny<IEnumerable<TData>>())).Callback<IEnumerable<TData>>(ts =>
            {
                foreach (var t in ts) { lstData.Remove(t); }
            });
            
            dbContext.Setup(x => x.SaveChangesAsync(CancellationToken.None)).ReturnsAsync(() => 1);

            // Added behavior for Update
            dbSetMock.Setup(x => x.Update(It.IsAny<TData>())).Callback<TData>(t => {
                var existingEntity = lstData.FirstOrDefault(e => e.Equals(t));
                if (existingEntity != null)
                {
                    lstData.Remove(existingEntity);
                    lstData.Add(t);
                }
            });

            dbContext.Setup(x => x.Set<TData>()).Returns(dbSetMock.Object);
            dbContext.Setup(dbSetSelectionExpression).Returns(dbSetMock.Object);

            return dbContext.Object;
        }
        
    }
}
