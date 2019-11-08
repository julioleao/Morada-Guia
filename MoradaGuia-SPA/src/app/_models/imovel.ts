import { Photo } from './photo';
import { User } from './user';

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
    userId: number;
    user: User;
    fotos?: Photo[];
}