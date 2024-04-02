import { ApiService } from "./api.service";
import { Component } from "@angular/core";
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule} from '@angular/material/card';

@Component({
    selector: 'question',
    standalone: true,
    imports: [FormsModule, HttpClientModule, MatCardModule, MatFormFieldModule, MatInputModule],
    templateUrl: './question.component.html',
    providers: [ApiService]
})

export class QuestionComponent { 
    question = { 
        Text: '', 
        CorrectAnswer: '',
        WrongAnswers: ['', '', '']}
    
    constructor(private apiService: ApiService) { }

    post(question: any): void { 
        this.apiService.postQuestion(question);
        console.log('Question: ' + question.Text);
    }
}