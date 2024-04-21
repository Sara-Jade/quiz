import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { QuestionComponent } from './question.component';
import { QuestionSetComponent } from './questionSet.component';
import { ApiService } from './api.service';
import { Question } from './question';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, QuestionComponent, QuestionSetComponent],
  template: '<question></question><questionSet></questionSet>',
  providers: [ApiService]
})

export class AppComponent implements OnInit{
  title = 'frontending';
  selectedQuestion: Question = { id: 0, text: 'default', correctAnswer: '', wrongAnswers: [] };

  constructor(private api: ApiService) { }

  ngOnInit(): void {
    this.api.selectedQuestion1.subscribe(question => { this.selectedQuestion = question });
  }
}
