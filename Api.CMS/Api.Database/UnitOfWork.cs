using System;
 

namespace Api.Database
{
    public class UnitOfWork : IDisposable
    {
        internal ContactContext context = new ContactContext();// new Microsoft.EntityFrameworkCore.DbContextOptions<ContactContext>());
        internal GenericRepository<Contact> contactRepository;
        internal GenericRepository<Status> statusRepository;

        public GenericRepository<Contact> ContactRepository
        {
            get
            {

                if (this.contactRepository == null)
                {
                    this.contactRepository = new GenericRepository<Contact>(context);
                }
                return contactRepository;
            }
        }

        public GenericRepository<Status> StatusRepository
        {
            get
            {

                if (this.statusRepository == null)
                {
                    this.statusRepository = new GenericRepository<Status>(context);
                }
                return statusRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
