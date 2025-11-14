# 🧮 Add Two Numbers – LeetCode #2

## 📌 Enunciado resumido

Dadas duas listas ligadas não vazias que representam dois números inteiros **não negativos**, onde:

- Cada nó contém **um único dígito**;
- Os dígitos estão armazenados em **ordem reversa**;
- As listas não possuem zeros à esquerda, exceto o número 0 em si.

Retorne uma nova lista ligada representando a **soma** dos dois números, também em ordem reversa.

---

## 🎯 Objetivo

Somar dois números representados por listas encadeadas **dígito a dígito**, considerando o **carry** (vai-um) da soma tradicional.

---

## 💡 Ideia da solução

O procedimento simula a soma manual:

342 + 465 = 807


Como as listas já vêm **invertidas**, basta percorrer ambas simultaneamente:

1. Somar `l1.val + l2.val + carry`;
2. Criar um nó contendo `soma % 10`;
3. Atualizar `carry = soma / 10`;
4. Avançar nas listas;
5. Ao final, se existir carry, criar um nó extra.

---

## 🧠 Estratégia passo a passo

1. Criar um nó “dummy” para facilitar a construção da resposta.
2. Criar um ponteiro `current` para o fim da lista resultante.
3. Inicializar `carry = 0`.
4. Enquanto ao menos uma das listas ainda tiver nós:
   - Pegar `v1` e `v2` (0 se já acabou).
   - Calcular `soma = v1 + v2 + carry`.
   - Criar um nó com `soma % 10`.
   - Atualizar `carry = soma / 10`.
   - Avançar `l1`, `l2` e `current`.
5. Se no final `carry > 0`, criar mais um nó.
6. Retornar `dummy.next`.

---

## ⏱️ Complexidade



