using homework_20.Models.Entity;
using homework_20.Models.Repositories.Intarfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.EntityFramework
{
    public class EFTextField : ITextField
    {
        private readonly ContextDb context;

        public EFTextField(ContextDb context) => this.context = context;

        void ITextField.DeleteTextField(Guid id)
        {
            context.TextFileds.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }

        TextField ITextField.GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFileds.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        TextField ITextField.GetTextFieldById(Guid id)
        {
            return context.TextFileds.FirstOrDefault(x => x.Id == id);
        }

        IQueryable<TextField> ITextField.GetTextFields()
        {
            return context.TextFileds;
        }

        void ITextField.SaveTextField(TextField entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
