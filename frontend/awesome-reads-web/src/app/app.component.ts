import { Component } from '@angular/core';
import { RouterOutlet, Router, NavigationEnd, ActivatedRouteSnapshot, } from '@angular/router';
import { HeaderComponent } from "./shared/components/header/header.component";
import { AvaliacoesFormComponent } from "./features/avaliacoes/components/avaliacoes-form/avaliacoes-form.component";
import { FooterComponent } from "./shared/components/footer/footer.component";
import { filter, map } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, AvaliacoesFormComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'AwesomeReads';

  isFullBleedRoute = false;

  constructor(private router: Router) {
    // estado inicial (refresh direto na rota)
    this.isFullBleedRoute = this.getFullBleedFromSnapshot(
      this.router.routerState.snapshot.root
    );

    this.router.events
      .pipe(filter((e): e is NavigationEnd => e instanceof NavigationEnd))
      .subscribe(() => {
        this.isFullBleedRoute = this.getFullBleedFromSnapshot(
          this.router.routerState.snapshot.root
        );

        console.log('url:', this.router.url, 'fullBleed:', this.isFullBleedRoute);
      });
  }

  private getFullBleedFromSnapshot(snapshot: ActivatedRouteSnapshot): boolean {
    let node: ActivatedRouteSnapshot | null = snapshot;
    while (node?.firstChild) node = node.firstChild; // leaf mais profundo
    return node?.data?.['fullBleed'] === true;
  }
}
