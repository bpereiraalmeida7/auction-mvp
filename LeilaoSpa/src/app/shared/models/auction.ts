export class Auction {
    id: number;
    nomeItem: string;
    valorInicial: number;
    dataAbertura: Date;
    dataFinalizacao: Date;
    responsavel: number;
    flagUsado: boolean = false;
}
