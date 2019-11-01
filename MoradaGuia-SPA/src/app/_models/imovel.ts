import { Photo } from './photo';

export interface Imovel {
    id: number;
    tipo: string;
    rua: string;
    numero: number;
    bairro: string;
    valor: number;
    qtdQuarto: number;
    qtdBanheiro: number;
    garagem: number;
    data: Date;
    urlFoto: string;
    fotos?: Photo[];
}
