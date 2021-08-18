//using System;
//using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Mvc.Filters;


//namespace ProjectX.MVC.Validation
//{
//    public class NormalValidateNullableFieldsAttribute : ActionFilterAttribute

//    {

//        public override void OnActionExecuting(ActionExecutingContext filterContext)

//        {

//            // Получаем ModelState, т.е. состояние модели

//            var modelState = filterContext.Controller.ViewData.ModelState;

//            // Получаем провайдер

//            var valueProvider = filterContext.Controller.ValueProvider;

//            // Получаем список параметров метода

//            var actionParameters = filterContext.ActionParameters;



//            // Получаем все Property для которых валидация произошла с ошибкой

//            var keysWithNoIncomingValue = modelState.Keys.Where(

//                    x => (

//                            // Параметра в коллекциях нет

//                            !valueProvider.ContainsPrefix(x)

//                            || (

//                                // Или параметр есть, но с пустым значением

//                                valueProvider.ContainsPrefix(x)

//                                && (

//                                    valueProvider.GetValue(x).AttemptedValue == "null"

//                                    || valueProvider.GetValue(x).AttemptedValue == ""

//                                )

//                            )

//                        )

//                        && modelState[x].Errors.Count > 0).ToList();

//            //var keysWithNoIncomingValue = modelState.Keys.Where(x => !valueProvider.ContainsPrefix(x) && modelState[x].Errors.Count > 0).ToList();



//            // Проходимся по каждому из ключей

//            foreach (var key in keysWithNoIncomingValue)

//            {

//                // Если элемент составной, т.е. является частью модели

//                if (key.Split('.').Length > 1)

//                {

//                    // Получаем свойства поля

//                    var member = actionParameters[key.Split('.')[0]].GetType().GetMember(key.Split('.')[1])[0];

//                    // Если тип является Generic

//                    if (((System.Reflection.PropertyInfo)member).PropertyType.IsGenericType)

//                    {

//                        // Если изначальным типом был тип Nullable<>

//                        if (((System.Reflection.PropertyInfo)member).PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)

//                            // И у поля не установлено кастомный атрибут Required

//                            && member.GetCustomAttributes(typeof(RequiredAttribute), true).Length == 0)

//                        {

//                            // То очищаем ошибку

//                            modelState[key].Errors.Clear();

//                        }

//                    }

//                    else

//                    {

//                        // Если у поля не установлен кастомный атрибут Required

//                        if (member.GetCustomAttributes(typeof(RequiredAttribute), true).Length == 0)

//                        {

//                            // То очищаем ошибку

//                            modelState[key].Errors.Clear();

//                        }

//                    }

//                }

//            }

//        }

//    }


//}


