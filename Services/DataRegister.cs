﻿using ToDoListWebAPI_HW.Models;

namespace ToDoListWebAPI_HW.Services
{
    public class DataRegister : IDataRegister
    {
        private readonly List<ITarget> targets = new List<ITarget>();

        public ITarget Add(ITarget target)
        {
            if (target is not null)
            {
                targets.Add(target);

                return target;
            }

            return null;
        }

        public List<ITarget> GetTargets()
        {
            return targets;
        }

        public ITarget ChangeTarget(ChangeTargetRequest request, int id)
        {
            var target = targets.FirstOrDefault(x => x.Id == id);
            if (target is not null && request is not null)
            {
                target.TargetValue = request.NewTargetValue;
                target.IsCompleted = request.IsCompleted;
                target.Description = request.Description;

                return target;
            }

            return null;
        }

        public ITarget DeleteTarget(int id)
        {
            var target = targets.FirstOrDefault(x => x.Id == id);

            if (target is not null)
            {
                targets.Remove(target);

                return target;
            }

            return null;
        }

        public ITarget GetTarget(int id)
        {
            return targets.FirstOrDefault(x => x.Id == id);
        }
    }
}
