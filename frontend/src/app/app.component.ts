import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { QuestionComponent } from './question.component';
import { QuestionSetComponent } from './questionSet.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, QuestionComponent, QuestionSetComponent],
  template: '<question></question><questionSet></questionSet>',
})

export class AppComponent {
  title = 'frontending';
}
