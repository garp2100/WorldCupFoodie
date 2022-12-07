import { Component, OnInit } from '@angular/core';
import { DishCrudService } from '../dish-crud.service';
import { Router, RouterModule, Routes } from '@angular/router';
import { WorldCupMatchesService } from '../world-cup-matches.service';
import { WorldCupMatchInfo } from '../world-cup-match-info';
import { WorldCupDish } from '../interface/world-cup-dish';
@Component({
  selector: 'app-add-dish',
  templateUrl: './add-dish.component.html',
  styleUrls: ['./add-dish.component.css']
})
export class AddDishComponent implements OnInit {
  allDishes: WorldCupDish[] = [];

  constructor(private dishcrudstuff: DishCrudService ,private router: Router,private service2:WorldCupMatchesService) { }
  focusedMatch = <WorldCupMatchInfo> {} as WorldCupMatchInfo;
  focusedDish = <WorldCupDish> {} as WorldCupDish;

  ngOnInit(): void {
    this.service2.getFocusedMatch().subscribe((data:WorldCupMatchInfo)=>this.focusedMatch=data);
    this.dishcrudstuff.getAllDishes().subscribe((data:WorldCupDish[])=>this.allDishes=data);
    this.dishcrudstuff.getFocusedDish(2).subscribe((data:WorldCupDish)=>this.focusedDish=data);

  }

  
}
