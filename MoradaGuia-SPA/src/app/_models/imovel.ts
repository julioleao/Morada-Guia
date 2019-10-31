import { Photo } from './photo';

export interface Imovel {
    id: number;
    tipo: string;
    rua: string;
    numero: number;
    bairro: string;
    valor: number;
    qtd_quarto: number;
    qtd_banheiro: number;
    garagem: number;
    data: Date;
    photoUrl: string;
    photos?: Photo[];
}
