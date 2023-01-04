import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})

export class IndexComponent implements OnInit {

  user: User;
  currentTutorial = null;
  currentIndex = -1;
  title = '';

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.retrieveTutorials();
  }

  retrieveTutorials(): void {
    this.userService.getAllUser()
    .subscribe(
      data => {
        this.tutorials = data;
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }

  refreshList(): void {
    this.retrieveTutorials();
    this.currentTutorial = null;
    this.currentIndex = -1;
  }

  setActiveTutorial(tutorial, index): void {
    this.currentTutorial = tutorial;
    this.currentIndex = index;
  }

  removeAllTutorials(): void {
    this.tutorialService.deleteAll()
      .subscribe(
        response => {
          console.log(response);
          this.retrieveTutorials();
        },
        error => {
          console.log(error);
        });
  }

  searchTitle(): void {
    this.tutorialService.findByTitle(this.title)
      .subscribe(
        data => {
          this.tutorials = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  } 
}
