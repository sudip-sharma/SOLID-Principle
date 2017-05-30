using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles
{
    class Without_Interface_Segregation_Principle
    {
        public interface ITeamLead
        {
            void CreateSubTask();
            void AssignTask();
            void WorkOnTask();
        }

        public class TeamLead : ITeamLead
        {
            public void CreateSubTask()
            {
                //code to create the task
            }

            public void AssignTask()
            {
                //code to assign the task
            }

            public void WorkOnTask()
            {
                //code to implement the performed assigned task
            }
        }

        /*
         ok so now the design is ready but later another role of the manager needs to be added who can assign
         the task but will not work on them. Now we can directly implement the ITeamLead interface to the manager
         class like this
         */

        public class Manager : ITeamLead
        {
            public void CreateSubTask()
            {
                //code to create the task
            }

            public void AssignTask()
            {
                //code to assign the task
            }

            public void WorkOnTask()
            {
                throw new Exception("Manager can't work on the task");
            }
        }

        /* 
            Since the manager will not be working on task and no one can assign task to the manager as well
            the implementation of the WorkOnTask method for the Manager is not suitable, so here we are 
            forcing the Manager class to implement a WorkOnTask() method without a purpose. This is wrong. The 
            design violates ISP. Let's correct the design
         */
    }

    class With_Interface_Segregation_Principle
    {

        /* 
            As we have three roles 
                1. Manager      :-  Creates and assign tasks
                2. Lead         :-  Create, assign and can work on the task
                3. Programmer   :-  Works on the task
             
            we need to divide the responsibility by segregating the ILead interface
         */

        public interface IProgrammer
        {
            void WorkOnTask();
        }

        public interface ILead
        {
            void CreateTask();
            void AssignTask();
        }

        //The implementation becomes something like

        public class Programmer : IProgrammer
        {
            public void WorkOnTask()
            {
                //code to work on task
            }
        }

        public class Manager : ILead
        {
            public void CreateTask()
            {
                //code to create the task
            }

            public void AssignTask()
            {
                //code to assign the task
            }
        }

        //Now as the Team Lead can create and assign the task and work on the task as well than Team Lead should
        //Implement both the IProgrammer and ILead

        public class TeamLead : IProgrammer, ILead
        {
            public void CreateTask()
            {
                //code to create the task
            }

            public void AssignTask()
            {
                //code to assign the task
            }

            public void WorkOnTask()
            {
                //code to work on the task
            }
        }
    }
}
