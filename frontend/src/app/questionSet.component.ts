import { ApiService } from "./api.service";
import { Component, OnInit } from "@angular/core";
import { FormsModule } from '@angular/forms';
import { MatCardModule } from "@angular/material/card";
import { MatListModule } from "@angular/material/list";
import { MatRadioModule } from '@angular/material/radio';
import { NgFor } from "@angular/common";
import { Question } from "./question";

// interface Question {
//     id: number;
//     text: string;
//     correctAnswer: string;
//     wrongAnswers: string[];
// }

@Component({
    selector: 'questionSet',
    standalone: true,
    imports: [FormsModule, MatCardModule, MatListModule, MatRadioModule, NgFor],
    templateUrl: './questionSet.component.html',
    providers: [ApiService]
})

export class QuestionSetComponent implements OnInit{ 
    selectedQuestion: Question = {} as Question;
    questions: Array<Question> = [];
    
    constructor(public api: ApiService) { }


    ngOnInit() {
        // (await this.apiService.getQuestionSet())
        this.api.getQuestionSet()
            .subscribe((response: any) => { 
                this.questions = [...response];
                console.log(`questions length:`);
                console.log(this.questions.length);
                console.log(`questions[0].text: ${this.questions[0].text}`);
            });

        this.api.selectedQuestion1.subscribe(question => { this.selectedQuestion = question });
    }

    onOptionChange(event: any) {
        console.log(`event.value: ${event.value}`);
        this.api.selectQuestion(event.value);
    }
}