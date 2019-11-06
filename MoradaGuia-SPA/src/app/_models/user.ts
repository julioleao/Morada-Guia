import { Imovel } from './imovel';

export interface User {
    id: number;
    username: string;
    email: string;
    telefone: string;
    criado: Date;
    ultimoLogin: Date;

    imovels?: Imovel[];
}