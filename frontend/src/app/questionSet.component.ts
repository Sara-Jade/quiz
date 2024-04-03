import { ApiService } from "./api.service";
import { Component } from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import { MatListModule } from "@angular/material/list";
import { NgFor } from "@angular/common";


@Component({
    selector: 'questionSet',
    standalone: true,
    imports: [MatCardModule, MatListModule, NgFor],
    templateUrl: './questionSet.component.html',
    providers: [ApiService]
})

export class QuestionSetComponent { 
    question = { 
        Text: '', 
        CorrectAnswer: '',
        WrongAnswers: ['', '', '']}

    questions: any;
    
    constructor(private apiService: ApiService) { }

    ngOnInit() {
        console.log('QuestionSetComponent initialized');
        this.apiService.getQuestionSet()
            .subscribe((response: object) => { this.questions = response; });
    }

    post(question: any): void { 
        this.apiService.postQuestion(question);
        console.log('Question: ' + question.Text);
    }
}