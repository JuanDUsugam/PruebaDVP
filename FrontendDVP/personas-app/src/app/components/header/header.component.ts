import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { UsuarioResponse } from '@app/store/usuario';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit{
  @Output() menuToggle = new EventEmitter<void>();
  @Input() user !: UsuarioResponse | null;
  @Input() isAuthorized !: boolean | null;
  @Output() signOut = new EventEmitter<void>();
  constructor(){}
  ngOnInit(): void {
    
  }

  onMenuToggleDispatch():void{
    this.menuToggle.emit();
  }

  onSignOut():void{
    this.signOut.emit();
  }

}
