import { Component, OnInit } from '@angular/core';
import { WorldCupMatchesService } from '../world-cup-matches.service';
import { WorldCupMatchInfo } from '../world-cup-match-info';
import { ReplaySubject } from 'rxjs';
import { Router, RouterModule, Routes } from '@angular/router';

@Component({
  selector: 'app-word-cup-matches',
  templateUrl: './word-cup-matches.component.html',
  styleUrls: ['./word-cup-matches.component.css']
})
export class WordCupMatchesComponent implements OnInit {
  allMatches: WorldCupMatchInfo[] = [];

  // constructor(private worldCupMatches: WorldCupMatchesService) { }

  // ngOnInit(): void {
  //   this.allMatches = this.worldCupMatches.getAllMatches();

  // }
  constructor(private service: WorldCupMatchesService, private router: Router) { }

  ngOnInit(): void {
  
  this.service.getAllMatches().subscribe((data:WorldCupMatchInfo[])=>this.allMatches=data);

  }
  goToEditMatch(id: number) {
    this.service.eventBeingUsed(id);
     this.router.navigate(['/poc/']); // route back to all tickets list
  }
  
}