import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// Вроде готово!
@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent {
  public courses: ICourseDto[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ICourseDto[]>(baseUrl + 'courses').subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }
}
interface ICourseDto {
  id: number;
  title: string;
  description: string;
  necessaryPreKnowledge: string;
  cost: number;
  specializationId: number;
  specialization: string;
}
